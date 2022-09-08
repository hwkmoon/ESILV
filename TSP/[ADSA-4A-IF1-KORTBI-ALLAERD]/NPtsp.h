#ifndef NPTSP_H
#define NPTSP_H
#include <vector>
#include <string>
#include <iostream>
#define H 5
#define N 71

using namespace std;
void NPtsp( double tab[N][N], string villes[N]);
void swap(int *x, int *y);
void permute(int *a, int i, int n);
void compare(double matrixDistance[N][N], string villes[N]);
#endif // !NPTSP_H
