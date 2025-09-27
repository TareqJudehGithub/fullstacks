import GrandFather from "./GrandParent";
import ValueContext from "./ValueContext";

export default function UseContextExample() {
	const message = "This is a message from UseContextExample component.";

	return (
		<ValueContext.Provider value={message}>
			<GrandFather />
		</ValueContext.Provider>
	);
}
