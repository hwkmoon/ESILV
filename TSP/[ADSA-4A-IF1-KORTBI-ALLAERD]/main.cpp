#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <cmath>
#include "kruskal.h"
#include "functions.h"
#include "NPtsp.h"
#define N 71
#define M_PI 3.1415926535897

using namespace std;

int main()
{
	string villeDepart;
	string villeDapres;
	ifstream file("Cites.csv");
	string villes[71];
	double tabLatLong[71][2];
	double adjencyMatrix[N][N];
	// Part to read the file Cites.csv which is in the source folder or root
	if (file)
	{
		string ligne;
		getline(file, ligne);
		int i = 0;
		while (getline(file, ligne))
		{
			/* We put all the data from "Citew.csv" into twho arrays: one for the latitude and 
			longitude and the second for the name and index of the city which related with the index of the first array*/
			istringstream iss(ligne);
			string newdata;
			float lat;
			float longit;
			getline(iss, newdata, ',');
			villes[i] = newdata;
			getline(iss, newdata, ',');
			istringstream(newdata) >> lat;
			tabLatLong[i][0] = lat;
			getline(iss, newdata, ',');
			istringstream(newdata) >> longit;
			tabLatLong[i][1] = longit;
			i++;
		}
		file.close();
		double distanceEntreVilles = 0;
		for (int a = 0;a < 71;a++)
		{
			for (int b = 0;b < 71;b++)
			{
				if (a != b)
				{	// We compute directy the distance that we put it in the adjency Matrix where i-row and j-column reprsent the distance between cities i and j.
					distanceEntreVilles = Distance(tabLatLong[a][0], tabLatLong[a][1], tabLatLong[b][0], tabLatLong[b][1]) ;
					if (distanceEntreVilles > 100)
					{
						adjencyMatrix[a][b] = distanceEntreVilles;
					}
					else
					{
					// All distances below 100 km we'll be counted like a 0 in the adjency Matrix which means for us, no edges
						adjencyMatrix[a][b] = 0;
					}
				}
				else
				{
					adjencyMatrix[a][b] = 0;
				}
			}

		}
	}
	else
	{
		cerr << "Impossible d'ouvrir le fichier !" << endl;
	}
	char choice='\0';
	char choice2 = '\0';
	cout << " Welcome to the traveling salesman problem!\n"
		<< "1. Find the maximum length path of the trip of traveling salesman problem\n"
		<< "starting from Paris and visits each city exactly one and returning to Paris\n"
		<< "2. Find  the minimum spanning tree containing edge Paris->Saint Georges\n"
		<< "Q. Quit.\n"
		<< "Your choice: \n";
	int q, s;
	for (int cpt = 0;cpt < N;cpt++)
	{
		if (villes[cpt] == "PARIS")
		{
			q = cpt;
		}
		if (villes[cpt] == "SAINT GEORGES")
		{
			s = cpt;
		}
		
	}
	// Interface with the user where he could choose the algorithm he wants to test.
	while(choice!='Q')
	{
		cin >> choice;
		switch (choice)
		{
			case '1':
				cout << "a. Use an exact method to find a solution.\n"
					 << "b. Use Lin-Kerighan heuristic's method.\n"
					 << "c. Use Local search heursitic's method.\n";
				cin >> choice2;
				switch (choice2)
				{
				case 'a':
					cout << "We find the maximum path for a number of cities equal to 5 because this algorithm takes a lots of time (many permutations)" << endl;
					NPtsp(adjencyMatrix,villes);
					break;
				case 'b':
					cout << "In process!" << endl;
					break;
				case 'c':
					cout << "In process!" << endl;
					break;
				}
				break;
			case '2':
				cout << " Find  the minimum spanning tree containing the edge Paris->Saint Georges\n with Kruskal's algorithm\n"
					 << "Wait few seconds please!" << endl;
				kruskalF(adjencyMatrix, q ,s, villes);
				break;
			case 'Q':
				break;
			default:
				cout << "We don't understand your choice. Please retry again!";
		}
	}
	return 0;
	
}
