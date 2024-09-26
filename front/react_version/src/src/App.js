import './App.css';

import 'react-toastify/dist/ReactToastify.css';
import {ToastContainer} from "react-toastify";

import Header from "./layOut/Header";
import Footer from "./layOut/Footer";
import InputReactiveComponent from "./components/InputReactiveComponent";
import VendorsViewLayout from "./components/vendorsView/VendorsViewLayout";
import ColorsWrapper from "./components/colors/ColorsWrapper";
import ToastifyComponent from "./components/helpers/ToastifyComponent";


function App() {
  return (
    <div className="App">
      <Header />
        <main>
            <ColorsWrapper />
        </main>
      <Footer />
        <ToastContainer />
    </div>
  );
}

export default App;
