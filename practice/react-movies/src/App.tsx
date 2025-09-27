import { useState } from "react";

import styles from "./App.module.css";

import ContentProjection2 from "./components/ContentProjection2";
import Header from "./components/Header";
import DisplayText from "./components/DisplayText";
import DynamicContent from "./components/DynamicContent";
import DynamicContentIf from "./components/DynamicContentIf";
import Table from "./components/Table";
import type { Person } from "./components/Person.model";
import UseEffectExample from "./components/UseEffectExample";
import UseContextExample from "./useContextExample/UseContextExample";
import MemoizationExample from "./components/MemoizationExample";
import ExampleMemoizationTable from "./memoization/ExampleMemoizationTable";

const personList: Person[] = [
	{ id: 1, fullName: "John Smith", department: "HR" },
	{ id: 2, fullName: "Sarah Adams", department: "IT" },
	{ id: 3, fullName: "Jessie James", department: "Acc" },
	{ id: 4, fullName: "Paulo Morino", department: "Sal" },
];

function App() {
	const subHeader: string = "This is my first React App";
	const double = (value: number) => value * 2;
	const viteLogo = "/vite.svg";

	const [message, setMessage] = useState("");
	const [isDisplayed, setIsDisplayed] = useState(false);
	const [grade, setGrade] = useState<number | null>(null);
	const [person, setPerson] = useState(personList);

	// useEffect example
	const [display, setIsDisplay] = useState(true);

	// Handlers
	function handleDelPerson(id: number) {
		setPerson((person) => person.filter((p) => p.id !== id));
	}

	return (
		<>
			<ContentProjection2
				header={
					<>
						<header>{<Header />}</header>
					</>
				}
				main={
					<>
						<>
							<h3 className={styles.main}>{subHeader}</h3>
							<h4>The double of 3 is {double(3)}</h4>
							<img src={viteLogo} alt="Vite logo" />

							<div>
								<input
									type="text"
									value={message}
									onChange={(e) => setMessage(e.target.value)}
								/>
								<DisplayText message={message} />
							</div>
							<div>
								<button onClick={() => setIsDisplayed((show) => !show)}>
									{isDisplayed ? <span>Hide</span> : <span>Shows</span>}
								</button>
								<input
									type="checkbox"
									onChange={(e) => setIsDisplayed(e.target.checked)}
								/>
								<DynamicContent displayContent={isDisplayed} />
							</div>
						</>
						<div>
							{/* <input
								type="number"
								value={grade}
								onChange={(e) => setGrade(Number(e.target.value))}
								placeholder="Enter a mark"
							/> */}
							<select
								value={Number(grade)}
								onChange={(e) => setGrade(Number(e.target.value))}
							>
								<option value="grade">Grade</option>
								<option value="90">90</option>
								<option value="75">75</option>
								<option value="60">60</option>
								<option value="45">45</option>
							</select>
							{grade != null && <DynamicContentIf grade={Number(grade)} />}
						</div>
						<Table person={person} onDelPerson={handleDelPerson} />

						<div>
							<input
								type="checkbox"
								defaultChecked={display}
								onChange={(e) => setIsDisplay(e.target.checked)}
							/>
							Display component
							{display ? <UseEffectExample /> : ""}
						</div>

						<UseContextExample />
						<MemoizationExample />
					</>

					// End of main
				}
				footer={
					<>
						<p>This is the footer</p>
					</>
				}
			></ContentProjection2>

			<ExampleMemoizationTable />
		</>
	);
}

export default App;
