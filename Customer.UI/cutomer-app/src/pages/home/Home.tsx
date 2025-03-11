import Example from "./Example";
import "./home.scss";

const Home = () => {
    return (
        <div className="users">
          <div className="info">
            <h3>Customers</h3>
          </div>
          <Example />
        </div>
      );
};

export default Home;