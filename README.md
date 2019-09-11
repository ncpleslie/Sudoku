## Feature List
- [x] 1. Check if row is valid
- [x] 2. Check if column is valid
- [x] 3. Check if square is valid
- [x] 4. Return possible values in empty space in row
- [x] 5. Return possible values in empty space in column
- [x] 6. Return possible values in empty space in square
- [x] 7. Reset Game to initial state
- [ ] 8. Number of moves remaining
- [x] 9. Cells are ReadOnly if contain data
- [x] 10. Ensure user input is within range
- [x] 11. Check if row/column/square contains blanks
- [x] 12. Check if row/column/square contains numbers within a valid range
- [x] 13. Check if row/column/square contains duplicate numbers
- [x] 14. Store each turn
- [x] 15. Ability to go back a turn
- [x] 16. Start Timer
- [x] 17. Stop Timer
- [x] 18. Return Time played

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

