import { useEffect, useState } from "react";

export default function UseEffect() {
	const [clicks, setClicks] = useState(0);
	const [time, setTime] = useState(new Date());

	useEffect(
		function () {
			console.log("Updating title");
			document.title = `${clicks} times`;
		},
		[clicks]
	);

	useEffect(function () {
		function tryUseEffect() {
			console.log("The component has loaded");
			return console.log("Cleaning up!");
		}
		tryUseEffect();
	}, []);

	useEffect(function () {
		const timerId = setInterval(() => {
			setTime(new Date());
		});
		return () => clearInterval(timerId);
	}, []);

	return (
		<>
			<h1>useEffect Example</h1>
			<button onClick={() => setClicks((clicks) => clicks + 1)}>Click</button>
			{clicks}

			<p>The current time is {time.toLocaleString()}</p>
		</>
	);
}
