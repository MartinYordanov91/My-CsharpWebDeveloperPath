function isExcellent(num) {
  //   if (num >= 5.5) {
  //     console.log(`Excellent`);
  //   } else {
  //     console.log(`Not excellent`);
  //   }

  let result = 5.5 <= num ? "Excellent" : "Not excellent";
  console.log(result);
}

isExcellent(5.5);
isExcellent(4.35);
