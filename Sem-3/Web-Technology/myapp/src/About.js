import Faculty from './App'

function About() {
    const facFormat = Faculty.map((fac) => (
        <div class="col-md-4 mb-4" key={fac.Name}>
            <div class="card">
                <img class="card-img-top" src={fac.img} alt="Card image cap" />
                <div class="card-body">
                    <h5 class="card-title">{fac.Name}</h5>
                    <p class="card-text">Subject: {fac.Subject}</p>
                </div>
            </div>
        </div>
    ));

    return (
        <div class="container mt-3">
            <div class="row">{facFormat}</div>
        </div>
    )
}

export default About