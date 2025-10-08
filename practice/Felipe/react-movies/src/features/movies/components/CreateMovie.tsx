import type { JSX } from "react";
import { useForm, type SubmitHandler } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import firstLetterUppercase from "../../../validations/firstLetterUppercase";
import { data, NavLink } from "react-router-dom";
import Button from "../../../components/Button";

export default function CreateMovie(): JSX.Element {
	const {
		register,
		handleSubmit,
		formState: { errors, isSubmitting },
	} = useForm<FormType>({
		resolver: yupResolver(validationRules),
		mode: "onChange",
	});

	const onSubmit: SubmitHandler<FormType> = async (data) => {
		await new Promise((resolve) => setTimeout(resolve, 500));
		console.log(data.title);
	};

	return (
		<form onSubmit={handleSubmit(onSubmit)}>
			<div className="form-group">
				<label htmlFor="title">Title</label>
				<input
					className="form-control"
					type="text"
					{...register("title")}
					name="title"
					autoComplete="off"
				/>
				{errors && <p className="error">{errors.title?.message}</p>}
			</div>
			<div className="mt-2">
				<Button type="submit" disabled={isSubmitting}>
					{isSubmitting ? "Sending.." : "Send"}
				</Button>
				<NavLink to="/" className="btn btn-bg-secondary ms-2">
					Cancel
				</NavLink>
			</div>
		</form>
	);
}

type FormType = {
	title: string;
};

const validationRules = yup.object({
	title: yup
		.string()
		.required("Movie title is required!")
		.test(firstLetterUppercase()),
});
