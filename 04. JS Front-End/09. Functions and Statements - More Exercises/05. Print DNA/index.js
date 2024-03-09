function printDNA(lengthDNA) {
  const dna = [
    ["A", "T"],
    ["C", "G"],
    ["T", "T"],
    ["A", "G"],
    ["G", "G"],
  ];

  for (let index = 0; index < lengthDNA; index++) {
    
    let curentLopDNA = index % 5;
    let left = dna[curentLopDNA][0];
    let right = dna[curentLopDNA][1];

    if (index % 4 === 0) {
      console.log(`**${left}${right}**`);
      continue;
    }

    if (index % 2 === 0) {
      console.log(`${left}----${right}`);
      continue;
    }

    console.log(`*${left}--${right}*`);
  }
}

printDNA(10);
