#include <stdio.h>
#include <vector>
#include <iostream>
#include "kruskal.h"
#include <string>
#define H 5
#define N 71
using namespace std;

struct edge {   // edge represented by a, b vertices and w the weight or distance here of the edge between a and b
	int a, b, w;
};
struct edgelist { // we need an edge list for kruskal algorithm
	vector <edge> listEdge;    // dynamic array because there is n=71 vertices, assuming that the graph is complete then we will need n(n-1)/2 edges = 2485 edges
	int n;
};
int n;
edgelist laListeEdge;
edgelist mstlist;
int cno1, cno2;
int belongs[N];
void sortL() // bubble sort, if we change it we can have a maximum spanning tree instead of a minimum spanning tree
{
	int i, j;
	edge temp;

	for (i = 1;i<laListeEdge.n;i++)
		for (j = 0;j<laListeEdge.n - 1;j++)
			if (laListeEdge.listEdge[j].w>laListeEdge.listEdge[j + 1].w) // we change here the order of the edge list, maximum or minimum spanning tree
			{
				temp = laListeEdge.listEdge[j];
				laListeEdge.listEdge[j] = laListeEdge.listEdge[j + 1];
				laListeEdge.listEdge[j + 1] = temp;
			}
}
// Find an edge
int findE(int belongs[] , int vertex)
{
	return(belongs[vertex]);
}
// Connect the vertices
void union1(int belongs[], int c1, int c2)
{
	int i;

	for (i = 0;i<n;i++)
		if (belongs[i] == c2)
			belongs[i] = c1;
}
// Print the miminum spanning tree
void print(string ville[N])
{
	int i ;
	int cost = 0;
	int j = 1;
	for (i = 0; i < mstlist.n; i++)
	{
		cout<< j <<" edge (" << ville[mstlist.listEdge[i].a] <<","<< ville[mstlist.listEdge[i].b] <<") = "<< mstlist.listEdge[i].w << endl;
		cost = cost + mstlist.listEdge[i].w;
		j++;
	}

	cout << "Cost of the spanning tree = " << cost << "km" << endl;
}
// We need this function because there is a constraint about the algorithm it has to have the edge "PARIS"->"SAINT GEORGES"
void AddEdgeDepart(int i, int j, double tab[N][N])
{
	mstlist.n = 0;
	edge depart;
	depart.a = i;
	depart.b = j;
	depart.w = tab[i][j];
	mstlist.listEdge.push_back(depart);
	mstlist.n++;
}
// Kruskal's algorithm
void kruskalF(double tab[N][N],int i, int j,string ville[N])
{
	AddEdgeDepart(i,j,tab);
	edge newEdge;
	cout << " Kruskal's algorithm: " << endl;
	laListeEdge.n = 0;
	cout << "Edge List : " << endl;
	for (int i = 0 ;i < N-1;i++)
		for (int j = 0;j < i;j++)
		{
			if (tab[i][j] != 0)
			{
				newEdge.a = i;
				newEdge.b = j;
				newEdge.w = tab[i][j];
				laListeEdge.listEdge.push_back(newEdge);
				laListeEdge.n++;
			}
		}
	sortL();
	for (int i = 0;i <N;i++)
	{
	
	belongs[i] = i;
	}
	for (int i = 0; i<N-2 ; i++)
	{	
		cno1 = findE(belongs, (laListeEdge.listEdge[i]).a);
		cno2 = findE(belongs, (laListeEdge.listEdge[i]).b);

		if (cno1 != cno2)
		{
			newEdge = laListeEdge.listEdge[i];
			mstlist.listEdge.push_back(newEdge);
			mstlist.listEdge[mstlist.n] = laListeEdge.listEdge[i];
			mstlist.n = mstlist.n + 1;
			union1(belongs, cno1, cno2);
		}
	}
	print(ville);

}



