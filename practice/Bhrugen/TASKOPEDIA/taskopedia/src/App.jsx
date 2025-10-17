import "./App.css";
import Footer from "./Layout/Footer";
import Header from "./Layout/Header";
import HomePage from "./Layout/HomePage";

function App() {
	return (
		<div className="">
			<Header />
			<HomePage />
			<Student />
			<Footer />
		</div>
	);
}

export default App;

function Student() {
	const fullName = "John Smith";
	const programmingExp = 2;
	return (
		<div className="container p-4 bg-success my-3 rounded">
			<div className="row border">
				<div className="col-2">IMAGE</div>
				<div className="col-8">
					{fullName}
					<br />
					Coding Experience {programmingExp} years
				</div>
			</div>
		</div>
	);
}
