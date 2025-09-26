export default function DynamicContentIf(props: DynamicContentIfProps) {
	if (props.grade >= 90) {
		return (
			<div>
				<h3 style={{ color: "blue" }}>Excellent!</h3>
			</div>
		);
	} else if (props.grade >= 70 && props.grade < 90) {
		return (
			<div>
				<h3 style={{ color: "green" }}>Good</h3>
			</div>
		);
	} else if (props.grade >= 50 && props.grade < 70) {
		return (
			<div>
				<h3 style={{ color: "orangered" }}>Poor</h3>
			</div>
		);
	} else if (props.grade > 0 && props.grade < 50) {
		return (
			<div>
				<h3 style={{ color: "red" }}>Failed</h3>
			</div>
		);
	} else {
		<div>
			<h3 style={{ color: "black" }}>Choose a mark</h3>
		</div>;
	}
}

interface DynamicContentIfProps {
	grade: number;
}
