import React,{ Fragment } from "react"
import ProductCarousel from "./ProductCarousel"
import "bootstrap/dist/css/bootstrap.min.css";
import { CardGroup } from "react-bootstrap";
import productData from "./data/food.json";
import ProductCard from "./ProductCard";

export default function Product({ cartItem, setCartItem }) {
    return (
      <Fragment>
        <ProductCarousel />
        <div style={{ marginTop: 20 }}>
          <CardGroup>
            {productData.map((product) => (
              <ProductCard
                key={product.name}
                {...product}
                cartItem={cartItem}
                setCartItem={setCartItem}
              />
            ))}
          </CardGroup>
        </div>
      </Fragment>
    );
  }