#include "NeuralNetworkPlus.h"
#include <iostream>
#include <vector>
#include <cmath>
#include <algorithm>
#include <numeric>
#include <random>
#include <fstream>

using namespace std;

// NeuralNetDemo.cpp
// Build: g++ NeuralNetworkPlus.cpp, NeuralNetDemo.cpp NeuralnetDemo
// Usage: ./NeuralNetDemo
// Demo: small classification with softmax output on XOR-like data
int main() {
    // XOR dataset
    vector<vector<double>> X = {
        {0,0}, {0,1}, {1,0}, {1,1}
    };
    vector<vector<double>> Y = {
        {1,0}, {0,1}, {0,1}, {1,0} // class0 for (0,0) and (1,1), class1 for (0,1),(1,0)
    };

    NeuralNetwork nn;
    // output of layer 1 => input of layer 2 => ...
    nn.addLayer(2, 8, Activation::LeakyReLU);
    nn.addLayer(8, 8, Activation::LeakyReLU);
    nn.addLayer(8, 8, Activation::LeakyReLU);
    nn.addLayer(8, 2, Activation::Softmax);

    nn.setStoredPredictionsEnabled(true);
    nn.setStoredBlendAlpha(0.7); // favor network output 70%

    double finalLoss = nn.trainBatch(X, Y, /*lr=*/0.1, /*l2=*/1e-4, /*epochs=*/5000, /*batchSize=*/4, /*shuffle=*/true);
    cout << "Training done. Loss=" << finalLoss << "\n";

    // Inference
    for (size_t i = 0; i < X.size(); ++i) {
        auto p = nn.forward(X[i]);
        cout << "Input [" << X[i][0] << "," << X[i][1] << "] -> probs [" << p[0] << ", " << p[1] << "]\n";
    }

    // Serialize
    string path = "nn.bin";
    nn.serialize(path);
    cout << "Serialized to " << path << "\n";

    // Deserialize into a new network and test
    NeuralNetwork nn2;
    nn2.deserialize(path);
    for (size_t i = 0; i < X.size(); ++i) {
        auto p = nn2.forward(X[i]);
        cout << "Deserialized net -> Input [" << X[i][0] << "," << X[i][1] << "] -> probs [" << p[0] << ", " << p[1] << "]\n";
    }

    return 0;
}
