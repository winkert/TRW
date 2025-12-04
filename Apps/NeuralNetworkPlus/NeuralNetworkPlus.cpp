#include "NeuralNetworkPlus.h"
#include <random>
#include <stdexcept>

using namespace std;

static inline double randUniform(double a=-0.5, double b=0.5) {
    static random_device rd;
    static mt19937 gen(rd());
    uniform_real_distribution<double> dist(a, b);
    return dist(gen);
}

static inline double sigma(double x) { return 1.0 / (1.0 + std::exp(-x)); }

static inline double activateSingle(double x, Activation act) {
    switch (act) {
        case Activation::Sigmoid:   return sigma(x);
        case Activation::Tanh:      return std::tanh(x);
        case Activation::Linear:    return x;
        case Activation::ReLU:      return x > 0 ? x : 0.0;
        case Activation::LeakyReLU: return x > 0 ? x : 0.01 * x;
        case Activation::Softmax:   return x; // handled as vector
    }
    return x;
}

static void activateVector(const vector<double>& z, vector<double>& a, Activation act) {
    size_t n = z.size();
    a.resize(n);
    if (act == Activation::Softmax) {
        double m = *max_element(z.begin(), z.end());
        double sum = 0.0;
        for (size_t i = 0; i < n; ++i) {
            a[i] = std::exp(z[i] - m);
            sum += a[i];
        }
        for (size_t i = 0; i < n; ++i) a[i] /= (sum > 0 ? sum : 1.0);
    } else {
        for (size_t i = 0; i < n; ++i) a[i] = activateSingle(z[i], act);
    }
}

static inline double dActivateSingle(double x, double a, Activation act) {
    switch (act) {
        case Activation::Sigmoid:   return a * (1.0 - a);
        case Activation::Tanh:      return 1.0 - a * a;
        case Activation::Linear:    return 1.0;
        case Activation::ReLU:      return x > 0 ? 1.0 : 0.0;
        case Activation::LeakyReLU: return x > 0 ? 1.0 : 0.01;
        case Activation::Softmax:   return 1.0; // handled via cross-entropy
    }
    return 1.0;
}

// Implement Layer methods declared in header
Layer::Layer() : inSize(0), outSize(0), act(Activation::Linear) {}

Layer::Layer(int inS, int outS, Activation activation)
    : inSize(inS), outSize(outS), act(activation), W(outS * inS), b(outS) {
    double scale = 1.0 / std::sqrt(static_cast<double>(inSize));
    if (act == Activation::ReLU || act == Activation::LeakyReLU) {
        scale = std::sqrt(2.0 / static_cast<double>(inSize));
    }
    for (auto &w : W) w = randUniform(-1.0, 1.0) * scale;
    for (auto &bi : b) bi = 0.0;
    z.resize(outSize);
    a.resize(outSize);
}

const vector<double>& Layer::forward(const vector<double>& input) {
    if (static_cast<int>(input.size()) < inSize) {
        throw runtime_error("Layer::forward: input size smaller than layer inSize");
    }
    for (int o = 0; o < outSize; ++o) {
        double s = 0.0;
        int base = o * inSize;
        for (int i = 0; i < inSize; ++i) s += W[base + i] * input[i];
        z[o] = s + b[o];
    }
    activateVector(z, a, act);
    return a;
}

vector<double> Layer::backward(const vector<double>& input,
                               const vector<double>& upstream,
                               vector<double>& dW, vector<double>& db) const {
    if (static_cast<int>(input.size()) < inSize) {
        throw runtime_error("Layer::backward: input size smaller than layer inSize");
    }
    vector<double> dz(outSize), deltaPrev(inSize, 0.0);
    if (act == Activation::Softmax) {
        dz = upstream;
    } else {
        for (int o = 0; o < outSize; ++o) {
            dz[o] = upstream[o] * dActivateSingle(z[o], a[o], act);
        }
    }
    dW.assign(outSize * inSize, 0.0);
    db.assign(outSize, 0.0);
    for (int o = 0; o < outSize; ++o) {
        int base = o * inSize;
        db[o] += dz[o];
        for (int i = 0; i < inSize; ++i) {
            dW[base + i] += dz[o] * input[i];
            deltaPrev[i] += W[base + i] * dz[o];
        }
    }
    return deltaPrev;
}

void Layer::applyGradients(const vector<double>& dW, const vector<double>& db, double lr, double l2) {
    for (int o = 0; o < outSize; ++o) {
        int base = o * inSize;
        for (int i = 0; i < inSize; ++i) {
            W[base + i] -= lr * (dW[base + i] + l2 * W[base + i]);
        }
        b[o] -= lr * db[o];
    }
}

void Layer::serialize(ofstream& ofs) const {
    int actInt = static_cast<int>(act);
    ofs.write(reinterpret_cast<const char*>(&inSize), sizeof(inSize));
    ofs.write(reinterpret_cast<const char*>(&outSize), sizeof(outSize));
    ofs.write(reinterpret_cast<const char*>(&actInt), sizeof(actInt));
    ofs.write(reinterpret_cast<const char*>(W.data()), W.size() * sizeof(double));
    ofs.write(reinterpret_cast<const char*>(b.data()), b.size() * sizeof(double));
}

void Layer::deserialize(ifstream& ifs) {
    int actInt;
    ifs.read(reinterpret_cast<char*>(&inSize), sizeof(inSize));
    ifs.read(reinterpret_cast<char*>(&outSize), sizeof(outSize));
    ifs.read(reinterpret_cast<char*>(&actInt), sizeof(actInt));
    act = static_cast<Activation>(actInt);
    W.resize(outSize * inSize);
    b.resize(outSize);
    z.resize(outSize);
    a.resize(outSize);
    ifs.read(reinterpret_cast<char*>(W.data()), W.size() * sizeof(double));
    ifs.read(reinterpret_cast<char*>(b.data()), b.size() * sizeof(double));
}

// NeuralNetwork implementations
void NeuralNetwork::addLayer(int inSize, int outSize, Activation act) {
    layers.emplace_back(inSize, outSize, act);
}

vector<double> NeuralNetwork::forward(const vector<double>& input) {
    const vector<double>* x = &input;
    for (auto& L : layers) x = &L.forward(*x);
    // copy network output
    std::vector<double> out = *x;

    // If stored-prediction blending is enabled and we have stored data, compute
    // an inverse-distance weighted stored prediction and blend it with network output.
    if (storedPredictionsEnabled && !storedX.empty() && !storedY.empty()) {
        // Ensure storedY rows match output dimension; fallback to network output on mismatch
        size_t outDim = out.size();
        // Prepare aggregated weighted sum
        std::vector<double> yAgg(outDim, 0.0);
        double weightSum = 0.0;
        const double eps = 1e-8;

        for (size_t si = 0; si < storedX.size(); ++si) {
            const auto &sx = storedX[si];
            const auto &sy = storedY[si];
            if (sy.size() != outDim) continue; // mismatch, skip

            // compute L2 distance between input and stored sample (use min length)
            double dist2 = 0.0;
            size_t len = std::min(input.size(), sx.size());
            for (size_t k = 0; k < len; ++k) {
                double d = input[k] - sx[k];
                dist2 += d * d;
            }
            double dist = std::sqrt(dist2);
            double w = 1.0 / (dist + eps);
            weightSum += w;
            for (size_t j = 0; j < outDim; ++j) yAgg[j] += w * sy[j];
        }

        std::vector<double> storedPred(outDim);
        if (weightSum > 0.0) {
            for (size_t j = 0; j < outDim; ++j) storedPred[j] = yAgg[j] / weightSum;
        } else {
            // no usable stored data, fallback to network
            return out;
        }

        // blend
        double alpha = storedBlendAlpha;
        if (alpha < 0.0) alpha = 0.0;
        if (alpha > 1.0) alpha = 1.0;
        std::vector<double> blended(outDim);
        for (size_t j = 0; j < outDim; ++j) blended[j] = alpha * out[j] + (1.0 - alpha) * storedPred[j];
        return blended;
    }

    return out;
}

double NeuralNetwork::computeLossAndDelta(const vector<double>& yPred,
                                          const vector<double>& yTrue,
                                          vector<double>& deltaOut) const {
    const Layer& last = layers.back();
    double loss = 0.0;
    if (last.act == Activation::Softmax) {
        double eps = 1e-12;
        for (size_t i = 0; i < yPred.size(); ++i) loss += -yTrue[i] * std::log(yPred[i] + eps);
        deltaOut.resize(yPred.size());
        for (size_t i = 0; i < yPred.size(); ++i) deltaOut[i] = yPred[i] - yTrue[i];
    } else {
        for (size_t i = 0; i < yPred.size(); ++i) {
            double diff = yPred[i] - yTrue[i];
            loss += 0.5 * diff * diff;
        }
        deltaOut.resize(yPred.size());
        for (size_t i = 0; i < yPred.size(); ++i) deltaOut[i] = yPred[i] - yTrue[i];
    }
    return loss;
}

double NeuralNetwork::trainSample(const vector<double>& x,
                                  const vector<double>& y,
                                  double lr, double l2) {
    vector<vector<double>> activations;
    activations.reserve(layers.size() + 1);
    activations.push_back(x);
    for (auto& L : layers) activations.push_back(L.forward(activations.back()));
    const vector<double>& yPred = activations.back();
    vector<double> delta;
    double loss = computeLossAndDelta(yPred, y, delta);

    vector<double> upstream = delta;
    for (int li = static_cast<int>(layers.size()) - 1; li >= 0; --li) {
        const vector<double>& inAct = activations[li];
        vector<double> dW, db;
        vector<double> deltaPrev = layers[li].backward(inAct, upstream, dW, db);
        layers[li].applyGradients(dW, db, lr, l2);
        upstream = std::move(deltaPrev);
    }
    return loss;
}

double NeuralNetwork::trainBatch(const vector<vector<double>>& X,
                                 const vector<vector<double>>& Y,
                                 double lr, double l2, int epochs, int batchSize, bool shuffle) {
    // If enabled, store the provided training data for later prediction/analysis
    if (storedPredictionsEnabled) {
        storeTrainingData(X, Y);
    }
    vector<int> idx(X.size());
    // fills idx with 0,1,2,...,N-1
    iota(idx.begin(), idx.end(), 0);
    double lastLoss = 0.0;
    for (int e = 0; e < epochs; ++e) {
        if (shuffle) {
            static random_device rd;
            static mt19937 gen(rd());
            std::shuffle(idx.begin(), idx.end(), gen);
        }
        double epochLoss = 0.0;
        int count = 0;
        for (int i : idx) {
            epochLoss += trainSample(X[i], Y[i], lr, l2);
            count++;
        }
        lastLoss = epochLoss / max(1, count);
    }
    return lastLoss;
}

void NeuralNetwork::serialize(const string& path) const {
    ofstream ofs(path, ios::binary);
    if (!ofs) throw runtime_error("Failed to open file for writing: " + path);
    uint32_t magic = 0x4E4E4249;
    uint32_t version = 1;
    ofs.write(reinterpret_cast<const char*>(&magic), sizeof(magic));
    ofs.write(reinterpret_cast<const char*>(&version), sizeof(version));
    uint32_t nLayers = static_cast<uint32_t>(layers.size());
    ofs.write(reinterpret_cast<const char*>(&nLayers), sizeof(nLayers));
    for (const auto& L : layers) L.serialize(ofs);
}

void NeuralNetwork::deserialize(const string& path) {
    ifstream ifs(path, ios::binary);
    if (!ifs) throw runtime_error("Failed to open file for reading: " + path);
    uint32_t magic=0, version=0;
    ifs.read(reinterpret_cast<char*>(&magic), sizeof(magic));
    ifs.read(reinterpret_cast<char*>(&version), sizeof(version));
    if (magic != 0x4E4E4249) throw runtime_error("Invalid file: bad magic");
    if (version != 1) throw runtime_error("Unsupported version");
    uint32_t nLayers=0;
    ifs.read(reinterpret_cast<char*>(&nLayers), sizeof(nLayers));
    layers.clear();
    layers.reserve(nLayers);
    for (uint32_t i = 0; i < nLayers; ++i) {
        Layer L;
        L.deserialize(ifs);
        layers.push_back(std::move(L));
    }
}

// Store training data (copy)
void NeuralNetwork::storeTrainingData(const vector<vector<double>>& X,
                                     const vector<vector<double>>& Y) {
    if (!storedPredictionsEnabled) throw runtime_error("storeTrainingData: stored predictions are disabled");
    if (X.size() != Y.size()) throw runtime_error("storeTrainingData: X and Y must have same number of samples");
    storedX = X;
    storedY = Y;
}

void NeuralNetwork::clearStoredData() {
    storedX.clear();
    storedY.clear();
}

void NeuralNetwork::setStoredPredictionsEnabled(bool enabled) {
    storedPredictionsEnabled = enabled;
    if (!enabled) {
        // clear any stored data when disabling
        clearStoredData();
    }
}

bool NeuralNetwork::isStoredPredictionsEnabled() const {
    return storedPredictionsEnabled;
}

void NeuralNetwork::setStoredBlendAlpha(double alpha) {
    storedBlendAlpha = alpha;
}

double NeuralNetwork::getStoredBlendAlpha() const {
    return storedBlendAlpha;
}

std::vector<double> NeuralNetwork::predictFromStored(size_t idx) {
    if (!storedPredictionsEnabled) throw runtime_error("predictFromStored: stored predictions are disabled");
    if (idx >= storedX.size()) throw runtime_error("predictFromStored: index out of range");
    return forward(storedX[idx]);
}

std::vector<std::vector<double>> NeuralNetwork::predictAllStored() {
    if (!storedPredictionsEnabled) throw runtime_error("predictAllStored: stored predictions are disabled");
    std::vector<std::vector<double>> out;
    out.reserve(storedX.size());
    for (size_t i = 0; i < storedX.size(); ++i) {
        out.push_back(forward(storedX[i]));
    }
    return out;
}
