
function HeaderComponent() {


    const siteName = "Hello React";

    const mainMenu = [
        {url: "/", text: "home"},
        {url: "/about", text: "about"},
    ];

    return(
        <header>

            <h1> {siteName}  </h1>
            <small> ==> asp @siteName </small>
            <nav>
            <ul>
                {mainMenu.map((item, index ) => (
                    <li id={index} key={index}>
                        <a href={item.url}>{item.text}</a>
                    </li>
                ))}
            </ul>
            </nav>

        </header>


    )
}



export default HeaderComponent;

