function sumEvenAndOdd(number) {
  let even = 0;
  let odd = 0;
  let textNumber = number.toString();

  for (let index = 0; index < textNumber.length; index++) {
    textNumber[index] % 2 === 0
      ? (even += Number(textNumber[index]))
      : (odd += Number(textNumber[index]));
  }

    console.log(`Odd sum = ${odd}, Even sum = ${even}`)
}

sumEvenAndOdd(1000435);
sumEvenAndOdd(3495892137259234);
