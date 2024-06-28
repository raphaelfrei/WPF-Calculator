using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator {
    static class SimpleMath {

        public static double Add(double x, double y) {
            return x + y;
        }

        public static double Subtraction(double x, double y) {
            return x - y;
        }

        public static double Multiplication(double x, double y) {
            return x * y;
        }

        public static double Division(double x, double y) {

            if (x == 0) {
                MessageBox.Show("Division by 0 is not supported!", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return x / y;
        }

    }
}
