function isPalindrome(params) {
    for (const number of params) {
        let string =number.toString()
        let reversedString = number.toString().split('').reverse().join('')
        console.log(string === reversedString)
    }
}


isPalindrome([123,323,421,121])
isPalindrome([32,2,232,1010])