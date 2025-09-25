import { useState } from "react";
import styles from "./App.module.css";
import Header from "./componets/Header";
import DisplayText from "./componets/DisplayText";
import ContentProjection from "./componets/ContentProjection";
import ContentProjection2 from "./componets/ContentProjection2";

function App() {
	const subHeader: string = "This is my first React App";
	const double = (value: number) => value * 2;
	const viteLogo = "/vite.svg";

	const [message, setMessage] = useState("");

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
						</>
					</>
				}
				footer={
					<>
						<p>This is the footer</p>
					</>
				}
			></ContentProjection2>
		</>
	);
}

export default App;
