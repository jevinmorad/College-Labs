import { useState } from 'react';
import './About.css'
import Faculty from './Data';

function About() {
    let [index, setIndex] = useState(0);
    return (
        <>
            <div className="card-container">
                <span className="left-arrow" onClick={() => setIndex((index - 1 + Faculty.length) % Faculty.length)}><i class="fa-solid fa-circle-chevron-left"></i></span>

                <div className="card">
                    <img className="card-img-top" src={Faculty[index].img} alt="Card image cap" />
                    <div className="card-body">
                        <h5 className="card-title">{Faculty[index].Name}</h5>
                        <p className="card-text">Subject: {Faculty[index].Subject}</p>
                    </div>
                </div>

                <span className="right-arrow" onClick={() => setIndex((index + 1) % Faculty.length)}><i class="fa-solid fa-circle-chevron-right"></i></span>
            </div>
        </>
    )
}

export default About