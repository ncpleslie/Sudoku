const raw sudoku data = 
{1,2,3,0,
2,2,3,0}

for loop = i = 0 to < maxNum
var row
for loop = j = 0 to < maxNum
var value = raw[i*maxNum+j]
var col = value

0*4+0 = 0 index
0*4+1 = 1 index
...
0*4+4 = 3 index

next row
1*4+0 = 4 index

put row and column num 

row = 2
col = 2
row -1
col -1

var value = raw[i*maxNum+j]

1*4+1 = 5 index
ans = 4

row = 1
col = 2
row -1
col -1

var value = raw[i*maxNum+j]

0*4+1 = 1 index

