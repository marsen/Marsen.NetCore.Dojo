import React, { Fragment, createContext, useContext } from "react";
import Product from './Product'
import {
  Container,
  Jumbotron,
  Table,
  Row,
  Col
} from "react-bootstrap";
import styled from "styled-components";
import "bootstrap/dist/css/bootstrap.min.css";

const CartContext = createContext([]);
const AppWrapper = styled.div`
  padding: 20px;
  color: ${(props) => props.color};
`;

function Welcome() {
  return (
    <>
      <Jumbotron>
        <h1>歡迎 Marsen Learning 商城</h1>
      </Jumbotron>
      <p>此商城為教學用途，請勿正式購買。</p>
    </>
  );
}

function SeeYou() {
  return <h1>Good Bye !</h1>;
}

function Cart() {
  const cartItems = useContext(CartContext);
  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>商品名稱</th>
          <th>商品敘述</th>
          <th>商品價格</th>
        </tr>
      </thead>
      <tbody>
        {cartItems.map(({ name, description, price }, index) => (
          <tr key={index}>
            <td>
              <input type="checkbox" />
            </td>
            <td>{name}</td>
            <td>{description}</td>
            <td>{price}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
}

export default function App() {
    // location pushState API
    const [pathname, setPathname] = React.useState("/");
    const [cartItem, setCartItem] = React.useState([]);
    return (
      <CartContext.Provider value={cartItem}>
        <AppWrapper color="black">
          <Container fluid>
            <Row>
              <Col>
                <Row>
                  <Col>
                    <div
                      style={{ cursor: "pointer" }}
                      onClick={() => setPathname("/")}
                    >
                      首頁
                    </div>
                  </Col>
                  <Col>
                    <div
                      style={{ cursor: "pointer" }}
                      onClick={() => setPathname("/product")}
                    >
                      產品頁
                    </div>
                  </Col>
                  <Col>
                    <div
                      style={{ cursor: "pointer" }}
                      onClick={() => setPathname("/cart")}
                    >
                      購物車 ({cartItem.length})
                    </div>
                  </Col>
                </Row>
              </Col>
              <Col className="d-flex justify-content-end">
                <div onClick={() => setPathname("/logout")}>登出</div>
              </Col>
            </Row>
            <div style={{ marginTop: 20 }}>
              {pathname === "/" ? <Welcome /> : null}
              {pathname === "/product" ? (
                <Product cartItem={cartItem} setCartItem={setCartItem} />
              ) : null}
              {pathname === "/cart" ? <Cart /> : null}
              {pathname === "/logout" ? <SeeYou /> : null}
            </div>
          </Container>
        </AppWrapper>
      </CartContext.Provider>
    );
  }