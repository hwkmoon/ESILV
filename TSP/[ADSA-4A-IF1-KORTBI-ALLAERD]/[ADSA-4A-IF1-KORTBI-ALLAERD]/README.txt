ADSA TD9-10
Project: The traveling salesman problem
Members of the team: KORTBI Hicham - ALLAERD Bastien

We choose to code in C++.

The traveling salesman problem who has to visit each city starting from a certain one and returning to the starting point.
Minimize the total length trip:
Criterias:
- read the file "Cites.csv"
- the data of the file "Cites.csv" give latitude and longitude, that we have to transform in distance in kilometers
- if the distance between 2 cities < 100km, no edges
- load it in data structure representing the graph, we decide to reprent it in an adjency Matrix.

PS: The latitude and longitude of Brest in the file are wrong but we still keep it.

Question 1.
Find the maximum length path of the trip of traveling salesman problem starting from "PARIS" and visits each city exactly once and returning to "PARIS.

a. Exact method to find the solution
If we see the problem, the path of the trip like a graph, it's an Hamilton Circuit (circuit using every vertex once).
The intuitive solution is to do all the permutations or circuits and find the minimum circuit or minimum-weighted Hamilton circuit.
It's called the Brute Force algorithm.
But the problem is that for N=71 vertices (cities), there is (N-1)! circuits so it takes a long time.
We decide to try the algorithm just with 5 cities for the example.
NPtsp.cpp and NPtsp.h are the files of this algorithm.
The explanation of the functions are explained in comments on the files.

b. Lin-Kernighan heuristic
At the beginning it randomly partitions graph on two sets, then it tries to find pair of vertices, one from each set, 
so as we exchange them, the total number of edges between those sets decreases.

c. Local search heuristic
It's called 2-opt too.
This algorithm improves the solution by rearranging two edges at a time, based on the exchange
or swap of a pair of edges.

Question 2.
We have to estimate the complexity of each algorithm.

- Brute Force algorithm, 0((N-1)!)
This algorithm is efficient, sure to find the exact solution but it's isn't optimal, it has to look at (N-1)! Hamilton circuits so it takes a long time.

- Lin-Kernighan heuristic, 0(N^2.2)
It's slower thant 2-opt but the results are much better.

- Local search heuristic or 2-opt heuristic, O(N^2)

Question 3.
We have to implement an algorithm to find the minimum spanning tree containing the edge “PARIS” -> ”SAINT GEORGES”.
kruskalF.cpp and kruskalF.h are the files for this algorithm.
The explanation of the functions are explained in comments on the files.

I choose the Kruskal’s algorithm because I thought I will use it for Question 1 by changing the order when we create an edge list , 
but I realized that Kruskal ‘s algorithm don’t visit each city just only once, so I decided to use it for this question.
The algorithm respect each step of Kruskal’s algorithm:
- create an edge list of a given graph (adjency matrix) with their weights (distance).
- sort this edge list in increasing weight order. (function sortL)
- pick up the edge with minimum weight.
- remove this edge on the list (I put in other edge list)
- connect the vertices (function union1) with given edge and if there is a cycle (function belongs and findE) we discard this edge.
- repeat the last 3 steps until we have N-1 edges (70 edges in total)
The we print the minimum spanning tree containing Paris and Saint-Georges (function kruskalF and print).

For this project, we use a lots of ressources in Internet and on moodle but there was 2 main ressources that we used to implement algorithms:
https://www.math.ku.edu/~jmartin/courses/math105-F11/Lectures/chapter6-part3.pdf
http://www.thecrazyprogrammer.com/2014/03/kruskals-algorithm-for-finding-minimum-cost-spanning-tree.html
Unfortunetaley, we don't success to implement the heuristic algorithm.



