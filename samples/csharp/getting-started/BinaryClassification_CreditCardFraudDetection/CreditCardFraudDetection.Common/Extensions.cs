﻿using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace CreditCardFraudDetection.Common
{
    public static class ConsoleExtensions
    {

        public static void ToConsole(this MultiClassClassifierMetrics result)
        {
            Console.WriteLine($"Acuracy macro: {result.AccuracyMacro}");
            Console.WriteLine($"Acuracy micro: {result.AccuracyMicro}");
            Console.WriteLine($"Log loss: {result.LogLoss}");
            Console.WriteLine($"Log loss reduction: {result.LogLossReduction}");
            Console.WriteLine($"Per class log loss: ");
            int count = 0;
            foreach (var logLossClass in result.PerClassLogLoss)
            {
                Console.WriteLine($"\t [{count++}]: {logLossClass}");
            }
            Console.WriteLine($"Top K: {result.TopK}");
            Console.WriteLine($"Top K accuracy: {result.TopKAccuracy}");

        }

        public static void ToConsole(this CalibratedBinaryClassificationMetrics result)
        {
            Console.WriteLine($"Area under ROC curve: {result.Auc}");
            Console.WriteLine($"Area under the precision/recall curve: {result.Auprc}");
            Console.WriteLine($"Entropy: {result.Entropy}");
            Console.WriteLine($"F1 Score: {result.F1Score}");
            Console.WriteLine($"Log loss: {result.LogLoss}");
            Console.WriteLine($"Log loss reduction: {result.LogLossReduction}");
            Console.WriteLine($"Negative precision: {result.NegativePrecision}");
            Console.WriteLine($"Positive precision: {result.PositivePrecision}");
            Console.WriteLine($"Positive recall: {result.PositiveRecall}");

        }

        public static void ToConsole(this RegressionMetrics result)
        {
            Console.WriteLine($"L1: {result.L1}");
            Console.WriteLine($"L2: {result.L2}");
            Console.WriteLine($"Loss function: {result.LossFn}");
            Console.WriteLine($"Root mean square of the L2 loss: {result.Rms}");
            Console.WriteLine($"R scuared: {result.RSquared}");
        }

        public static ITransformer ReadModel(this MLContext mlContext, string modelLocation)
        {
            ITransformer model;
            using (var file = File.OpenRead(@modelLocation))
            {
                model = mlContext.Model.Load(file);
            }
            return model;
        }
    }

}
