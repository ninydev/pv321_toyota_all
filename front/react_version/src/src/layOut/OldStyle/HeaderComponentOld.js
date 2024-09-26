import React, { Component } from 'react';

class HeaderComponent extends Component {

    // Метод класса вместо приватной функции
    privateFunction() {
        console.log("Test");
    }

    // Метод render для отображения JSX
    render() {
        // Вызов приватной функции внутри метода render
        this.privateFunction();

        return (
            <header>
                <h1>Site Name </h1>
                <nav>
                    <ul>
                        <li>Home</li>
                    </ul>
                </nav>
            </header>
        );
    }
}

export default HeaderComponent;
