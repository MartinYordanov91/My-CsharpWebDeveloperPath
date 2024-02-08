function sumDigitsFromNumber(number) {
  const numberToString = number.toString();
  let sum = 0;

  for (let index = 0; index < numberToString.length; index++) {
    sum += Number(numberToString[index]);
  }
  console.log(sum);
}


sumDigitsFromNumber(245678)
sumDigitsFromNumber(97561)
sumDigitsFromNumber(543)