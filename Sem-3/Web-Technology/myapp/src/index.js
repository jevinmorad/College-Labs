import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route, Outlet, Link } from 'react-router-dom';

const root = ReactDOM.createRoot(document.getElementById('root'));

function Layout() {
    return (
        <>
            <div class="row g-4">
                <nav class="navbar navbar-expand-lg bg-body-tertiary">
                    <div class="container-fluid">
                        <div class="col-2">
                            <img src="https://th.bing.com/th/id/OIP.K-4RqDC6zFrpAG31ayDDOgHaHa?rs=1&pid=ImgDetMain" width={100}></img>
                        </div>
                        <div class="navbar-nav col gx-2 fs-5">
                            <Link class="nav-link px-5" to="/home">Home</Link>
                            <Link class="nav-link px-5" to="/about">About us</Link>
                            <Link class="nav-link px-5" to="/contact">Contact us</Link>
                        </div>

                    </div>
                </nav>
            </div>
            <Outlet />
        </>
    )
}
function Home() {
    return (<h1 class="text-center">Home page</h1>)
}
function About() {
    return (<h1 class="text-center">About us page</h1>)
}
function Contact() {
    return (<h1 class="text-center">Contact us page</h1>)
}

root.render(
    <BrowserRouter>
        <Routes>
            <Route path="/" element={<Layout />}>
                <Route path="/home" element={<Home />} />
                <Route path="/about" element={<About />} />
                <Route path="/contact" element={<Contact />} />
            </Route>
        </Routes>
    </BrowserRouter>
);
reportWebVitals();
