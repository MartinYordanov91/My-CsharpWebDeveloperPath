function reversArrayNumbers(number, array){
    let newArry = array.slice(0,number);
    console.log(newArry.reverse().join(" "))
}

reversArrayNumbers(3, [10, 20, 30, 40, 50])
reversArrayNumbers(4, [-1, 20, 99, 5])
reversArrayNumbers(2, [66, 43, 75, 89, 47])