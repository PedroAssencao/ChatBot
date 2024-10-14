export default function Input(props) {
    const className = props.className !== undefined ? props.className : "form-control p-3 backgroudVerderInput";

    return (
        <input
            id={props.id}
            value={props.value} 
            onChange={(e) => props.onChange && props.onChange(e)}
            className={className}
            placeholder={props.placeholder}
        />
    );
}
