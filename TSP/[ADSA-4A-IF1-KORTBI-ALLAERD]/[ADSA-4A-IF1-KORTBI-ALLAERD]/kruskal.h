#ifndef KRUSKAL_H
#define KRUSKAL_H
#define N 71
#include <vector>
#include <string>
using namespace std;

void sortL();
void AddEdgeDepart(int i, int j, double tab[N][N]);
int findE(int belongs[], int vertex);
void union1(int belongs[], int c1, int c2);
void print(string ville [N]);
void kruskalF(double tab[N][N],int i, int j, string ville[N]);
#endif
