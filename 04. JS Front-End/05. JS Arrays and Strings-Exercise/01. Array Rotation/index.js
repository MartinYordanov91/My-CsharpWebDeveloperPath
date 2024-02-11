function rotation(array, count){
    for (let index = 0; index < count; index++) {
       array.push(array.shift())
    }
    console.log(array.join(" "))
}

rotation([51, 47, 32, 61, 21], 2)
rotation([32, 21, 61, 1], 4)
rotation([2, 4, 15, 31], 5)