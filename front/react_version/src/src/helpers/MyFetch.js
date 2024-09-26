import MyError from "./MyError";
import MyLog from "./MyLog";


export const MyFetch = async (url, options = {}) => {

    url = 'http://localhost:5227/api/' + url;

    try {
        const response = await fetch(url, {
            headers: {
                // 'Content-Type': 'application/json',
                'Accept-Language': 'uk-UA, ru-RU;q=0.9',
                // Здесь можно добавить авторизацию
                // 'Authorization': `Bearer ${yourToken}`,
            },
            ...options,
        });

        // if (!response.ok ) {
        //     throw new Error(`Error: ${response.status}`);
        // }

        MyLog(response.statusText)

        return await response.json();
    } catch (error) {
        MyError(error)
        // throw error;
    }
};