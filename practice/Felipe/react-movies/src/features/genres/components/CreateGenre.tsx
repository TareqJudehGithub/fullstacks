// React
import type { JSX } from "react";
import { useForm, type SubmitHandler } from "react-hook-form";
import { NavLink } from "react-router-dom";

// Components
import Button from "../../../components/Button";
import { yupResolver } from "@hookform/resolvers/yup";

// Yup validation
import * as yup from "yup";

import firstLetterUppercase from "../../../validations/firstLetterUppercase";

export default function CreateGenre(): JSX.Element {
	const {
		register,
		handleSubmit,
		formState: { errors, isValid, isSubmitting },
	} = useForm<FormType>({
		resolver: yupResolver(validationRules),
		mode: "onChange",
	});

	// A function that can be executed when using React Hook Form
	const onSubmit: SubmitHandler<FormType> = async (data) => {
		await new Promise((resolve) => setTimeout(resolve, 500));
		console.log(data);
	};

	return (
		<>
			<h4>Create Genre</h4>
			<form onSubmit={handleSubmit(onSubmit)}>
				<div className="form-group">
					<label htmlFor="name">Name</label>
					<input
						className="form-control"
						type="text"
						autoFocus
						{...register("name")}
						autoComplete="off"
					/>
					{errors.name && <p className="error">{errors.name.message}</p>}
				</div>

				<div className="form-group">
					<label htmlFor="email">Email</label>
					<input
						className="form-control"
						type="email"
						autoComplete="off"
						{...register("email")}
					/>
					{errors.email && <p className="error">{errors.email.message}</p>}
				</div>
				<div className="mt-2">
					{/* If the form is not valid to submit, or is submitting, then disable the Button. */}
					<Button type="submit" disabled={isSubmitting}>
						{isSubmitting ? "Sending..." : "Send"}
					</Button>

					<NavLink to="/genres" className="btn btn-bg-secondary ms-2">
						Cancel
					</NavLink>
				</div>
			</form>
		</>
	);
}

interface FormType {
	name: string;
	email: string;
}

// Validation rules
const validationRules = yup.object({
	name: yup
		.string()
		.required("Name is required!")
		.test(firstLetterUppercase()),
	email: yup.string().required("Email is required"),
});
