function largestNumber(...numbers) {
  let largesNum = numbers.sort(function (a, b) {
    return b - a;
  })[0];
  console.log(`The largest number is ${largesNum}.`)
}


largestNumber(-3, -5, -22.5)
largestNumber(5, -3, 16)