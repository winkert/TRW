// NeuralNetworkPlus.h
#ifndef NEURALNETWORK_HPP
#define NEURALNETWORK_HPP

#include <iostream>
#include <vector>
#include <cmath>
#include <algorithm>
#include <numeric>
#include <random>
#include <fstream>
#include <stdexcept>
#include <string>
#include <utility>

// Activation function types
enum class Activation {
    Sigmoid = 0,
    Tanh    = 1,
    Linear  = 2,
    ReLU    = 3,
    LeakyReLU = 4,
    Softmax = 5
};

struct Layer {
    int inSize;
    int outSize;
    Activation act;
    std::vector<double> W;
    std::vector<double> b;

    std::vector<double> z;
    std::vector<double> a;

    Layer();
    Layer(int inS, int outS, Activation activation);

    const std::vector<double>& forward(const std::vector<double>& input);
    std::vector<double> backward(const std::vector<double>& input,
                                 const std::vector<double>& upstream,
                                 std::vector<double>& dW,
                                 std::vector<double>& db) const;
    void applyGradients(const std::vector<double>& dW,
                        const std::vector<double>& db,
                        double lr, double l2=0.0);

    void serialize(std::ofstream& ofs) const;
    void deserialize(std::ifstream& ifs);
};

struct NeuralNetwork {
    std::vector<Layer> layers;

    // Optional stored training data (useful for later predictions / analysis)
    std::vector<std::vector<double>> storedX;
    std::vector<std::vector<double>> storedY;
    // Enable/disable stored-data behavior
    bool storedPredictionsEnabled{false};
    // Blend factor when combining network prediction with stored-data prediction.
    // 1.0 = only network, 0.0 = only stored-data. Range [0,1].
    double storedBlendAlpha{0.5};

    void addLayer(int inSize, int outSize, Activation act);
    std::vector<double> forward(const std::vector<double>& input);

    double computeLossAndDelta(const std::vector<double>& yPred,
                               const std::vector<double>& yTrue,
                               std::vector<double>& deltaOut) const;

    double trainSample(const std::vector<double>& x,
                       const std::vector<double>& y,
                       double lr=0.01, double l2=0.0);

    double trainBatch(const std::vector<std::vector<double>>& X,
                      const std::vector<std::vector<double>>& Y,
                      double lr=0.01, double l2=0.0,
                      int epochs=10, int batchSize=32, bool shuffle=true);

    void serialize(const std::string& path) const;
    void deserialize(const std::string& path);

    // Training-data storage API
    void storeTrainingData(const std::vector<std::vector<double>>& X,
                           const std::vector<std::vector<double>>& Y);
    void clearStoredData();

    // Enable/disable stored-data operations
    void setStoredPredictionsEnabled(bool enabled);
    bool isStoredPredictionsEnabled() const;
    // Blend factor setter/getter (alpha in [0,1], higher favors network output)
    void setStoredBlendAlpha(double alpha);
    double getStoredBlendAlpha() const;

    // Predict using stored training sample index
    std::vector<double> predictFromStored(size_t idx);
    // Predict for all stored training samples
    std::vector<std::vector<double>> predictAllStored();
};

#endif // NEURALNETWORK_HPP
