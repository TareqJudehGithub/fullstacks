import { useState, useMemo } from "react";

export default function MemoizationExample() {
	const [myNumber, setMyNumber] = useState(1);
	const [myName, setMyName] = useState("");

	const calculateFactorial = useMemo(
		function calculateFactorial() {
			console.log("Calculating the factorial");
			let result = 1;

			for (let i = 1; i <= myNumber; i++) {
				result *= i;
			}
			return result;
		},
		[myNumber]
	);

	return (
		<>
			<h1>Memoization: useMemo Hook example</h1>
			<input
				type="text"
				value={myNumber}
				onChange={(e) => setMyNumber(Number(e.target.value))}
			/>
			<p>
				The Factorial of {myNumber} is {calculateFactorial}
			</p>
			<input
				type="text"
				value={myName}
				onChange={(e) => setMyName(e.target.value)}
			/>
			<p>Your name is: {myName}</p>
		</>
	);
}
