export default function HomePage() {
	const courseName = "React.JS";
	const lectureCount = 11;
	const isActive = true;
	return (
		<main>
			<h3>Topics to learn in {courseName}</h3>
			<p>Lecture Count - {lectureCount}</p>
			<p>Is Active: {isActive ? "Active" : "Inactive"}</p>
			<ul>
				<li>JSX</li>
				<li>Components</li>
				<li>Routing</li>
				<li>State Management</li>
			</ul>

			<div>
				Enter Task:
				<input type="text" maxLength={12} disabled={isActive} />
			</div>
		</main>
	);
}
