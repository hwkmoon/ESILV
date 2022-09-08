#include <stdio.h>
#include <iostream>
#include <string>
#include <cmath>
#include "functions.h"
#define N 71
#define M_PI 3.1415926535897

using namespace std;

// A file containing the functions needed in this project

//Convert degrees in radians
double convertRad(double x)
{
	return (M_PI * x) / 180;
}
double Distance(double lat1, double longit1, double lat2, double longit2) 
{

	int R = 6378; // Radius of the Earth

	lat1 = convertRad(lat1);
	longit1= convertRad(longit1);
	lat2 = convertRad(lat2);
	longit2 = convertRad(longit2);

	double d = R * (M_PI / 2 - asin(sin(lat2) * sin(lat1) + cos(longit2 - longit1) * cos(lat2) * cos(lat1)));
	return d;
}