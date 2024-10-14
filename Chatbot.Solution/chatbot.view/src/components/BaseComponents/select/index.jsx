export default function Select(props) {
    const className = props.className !== undefined ? props.className : "form-select p-3 backgroudVerderInput";

    const handleChange = (event) => {
        const selectedValue = event.target.value;
        props.onChange(selectedValue);
    };

    return (
        <select
            id={props.id}
            onChange={handleChange}
            className={className}
            placeholder={props.placeholder}
        >
            {props.optionsList.map((x) => (
                <option value={x.value} key={x.id}>
                    {x.descricao}
                </option>
            ))}
        </select>
    );
}
