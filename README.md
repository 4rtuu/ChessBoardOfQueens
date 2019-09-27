# ChessBoardOfQueens
Console app of chessboard with queens

There is an n*n chess board with some queens placed on it in positions provided.
Task is to figure out which of the remaining positions on the chess board is still
possible to place a queen on, in such a way that it will not be in danger of being taken by
another queen, using chess rules. Output this n*n board on console screen using these symbols:

"O" - an existing queen's position
"X" - a position that is in danger
"W" - a possible position for another queen

The number n and at least one existing queen position (a, b) will be provided in a file input.txt
separated by semicolons.

Example of input file contents: 4;0,1;3,3

Example of expected output:
 

X O X X
X X X X
W X X X
X X X O
