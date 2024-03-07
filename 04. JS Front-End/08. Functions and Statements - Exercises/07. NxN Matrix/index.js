function printMatrix(size) {
    for (let index = 0; index < size; index++) {
        console.log(new Array(size).fill(size).join(" "))
    }
}

printMatrix(3)
printMatrix(7)
printMatrix(50)