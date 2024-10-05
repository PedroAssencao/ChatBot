export default function Input(props) {
    return (
        <input id={props.id} onChange={props.onChange} className="form-control p-3" placeholder={props.placeholder}
            style={{backgroundColor: "#b0dea5"}} />
    )
}