function sameNumbers(number) {
    const numberArrey = Array.from(String(number) ,Number)
    let setss = new Set(numberArrey).size <= 1;
    let sum = numberArrey.reduce((acomulator, curentValue) =>{
        return acomulator +=curentValue
    },0)
    console.log(setss);
    console.log(sum);
  
}

sameNumbers(2222222);
sameNumbers(1234);
