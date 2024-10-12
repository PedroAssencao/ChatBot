export default function Input(props) {
    const className = props.className !== undefined ? props.className : "form-control p-3 backgroudVerderInput"
    return (
        <input id={props.id} onChange={props.onChange} className={className} placeholder={props.placeholder}/>
    )
}