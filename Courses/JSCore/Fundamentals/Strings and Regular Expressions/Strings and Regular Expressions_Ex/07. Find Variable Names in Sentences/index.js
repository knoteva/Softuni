function solve(arr) {
    let pattern = /\b_[a-zA-Z0-9]+\b/g;
    let result= '';

   
   result= arr.match(pattern);


  // result = result.substring(1);
   let res = '';
   result.forEach(el => {
    el = el.substring(1);
   res += el + ',';
   });
   console.log(res.substring(0, res.length - 1))
   
}
solve('__invalidVariable _evenMoreInvalidVariable_ _validVariable')