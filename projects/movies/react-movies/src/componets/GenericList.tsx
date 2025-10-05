import React from "react";
import Loading from "../features/movies/components/Loading";

export default function GenericList<T>(props: GenericListProps<T>) {
	if (!props.list) {
		return props.loadingUI ? props.loadingUI : <Loading />;
	} else if (props.list.length === 0) {
		return props.emptyListUI
			? props.emptyListUI
			: "Your movies List is empty!";
	} else {
		return props.children;
	}
}

interface GenericListProps<T> {
	list: T[] | undefined;
	children: React.ReactNode;
	loadingUI?: React.ReactNode; // Loads when list is yet empty. Can override the custom message defined above in the If statement.
	emptyListUI?: React.ReactNode; // Loads when list has zero elements. Can override the custom message defined above in the If statement.
}

/* 
if (!props.movies) {
		return <h3>Loading please wait..</h3>;
	} else if (props.movies.length === 0) {
		return <h3>There are no movies!</h3>;
	} 


*/
