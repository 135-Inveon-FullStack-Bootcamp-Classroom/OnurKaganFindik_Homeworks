import React, { useState, useEffect } from 'react';
import './App.css';


const App = () => {
  //https://fakestoreapi.com/products
  const [products, setProducts] = useState([]);
   //state for products array 
  console.log(products);
  useEffect(() => {
    fakestore();
  }, [])

  //async function to get data from fake store api 


  const fakestore = async () => {
    const response = await fetch('https://fakestoreapi.com/products');
    const data = await response.json();
    // console.log(data);
    setProducts(data);

  }

    //returns the products array

  return (
    <>
      <h2>Fake Store</h2>
      <div className="container">
        {products.map((values) => {
          return (
            <>
              <div className="box">
                <div className="content">
                  <h5>{values.title}</h5>
                  <p>{values.description}</p>
                </div>
                <img src={values.image} alt="" />
              </div>
            </>
          )
        })}
      </div>
    </>
  );
}




export default App;
