import { useState, useEffect } from "react";
import "./App.css";

function Watch() {
	const [count, setCount] = useState(0);
	const [currentDate, setCurrentDate] = useState(new Date());

	useEffect(function () {
		const timerId = setInterval(() => {
			setCurrentDate(new Date());
		}, 1000);
		return () => clearInterval(timerId);
	}, []);

	return (
		<>
			<h3>React Example</h3>
			<input type="text" />
			<p>Time: {currentDate.toLocaleString()}</p>
		</>
	);
}

export default Watch;
