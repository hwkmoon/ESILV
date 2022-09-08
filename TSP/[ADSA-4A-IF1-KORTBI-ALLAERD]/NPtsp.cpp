#include "NPtsp.h"

struct path
{
	int e1;
	int e2;
	int e3;
	int e4;
	int e5;
};
vector <path> thePaths;
// Function to switch, to swap
void swap(int *x, int *y)
{
	int temp;
	temp = *x;
	*x = *y;
	*y = temp;
}
//Compute the sum of distance between cities of a path
double calculCostPath(path way, double matrixDistance[N][N])
{
	double distanceP=0;
	distanceP += matrixDistance[way.e1][way.e2];
	distanceP += matrixDistance[way.e2][way.e3];
	distanceP += matrixDistance[way.e3][way.e4];
	distanceP += matrixDistance[way.e4][way.e5];
	return distanceP;

}
// Give all permutations of an array given that we memorized on a vector thePaths 
void permute(int *a, int i, int n)
{
	int j;
	if (i == n)
	{
		path newPath;
		newPath.e1 = a[0];
		newPath.e2 = a[1];
		newPath.e3 = a[2];
		newPath.e4 = a[3];
		newPath.e5 = a[4];
		thePaths.push_back(newPath);
	}
	else
	{
		for (j = i; j <= n; j++)
		{
			swap((a + i), (a + j));
			permute(a, i + 1, n);  // Use of recursion here
			swap((a + i), (a + j));
		}
	}
}
//compare all the paths and print the maximum length path of all with the name of the cities and the total distance of the path
void compare(double matrixDistance[N][N],string villes[N])
{
	double distanceRef = 0;
	int compt = 0;
	for (int i = 0;i < thePaths.size();i++)
	{
		if (calculCostPath(thePaths[i], matrixDistance)>distanceRef)
		{
			distanceRef = calculCostPath(thePaths[i], matrixDistance);
			compt = i;
		}
	}
	cout << thePaths[compt].e1 << "->" << thePaths[compt].e2 << "->" << thePaths[compt].e3 << "->"
		<< thePaths[compt].e4 << "->" << thePaths[compt].e5 << endl;
	cout << "Cost of the maximum path: " << distanceRef << " km" << endl;;
	cout << "Maximum Path: " <<villes[thePaths[compt].e1] << "->" << villes[thePaths[compt].e2]
		<< "->" << villes[thePaths[compt].e3] << "->" << villes[thePaths[compt].e4] << "->" << villes[thePaths[compt].e5]
		<<  endl;

}
// Test the permutations only for 5 cities because it's O(n!) time complexity
void NPtsp( double tab[N][N],string villes[N])
{
	vector <path> thePaths;
	int a[] = { 32,47,47,12,62};
	permute(a, 0, 4);
	compare( tab,villes);
	
}