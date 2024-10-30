export default function Select(props) {
    const { optionsList, onChange, id, className, placeholder } = props;

    // Verifica se as props necessárias estão presentes e se optionsList possui conteúdo
    if (!optionsList || optionsList.length === 0 || !onChange || !id) {
        return null;
    }

    const selectClassName = className || "form-select p-3 backgroudVerderInput";

    const handleChange = (event) => {
        const selectedValue = event.target.value;
        onChange(selectedValue);
    };

    return (
        <select
            id={id}
            onChange={handleChange}
            className={selectClassName}
            placeholder={placeholder}
        >
            {optionsList.map((x) => (
                <option value={x.value} key={x.id}>
                    {x.descricao}
                </option>
            ))}
        </select>
    );
}
