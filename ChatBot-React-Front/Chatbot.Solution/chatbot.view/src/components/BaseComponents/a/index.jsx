import './style.css'

export default function a(props) {
    return (
        <a id={props.id} className={props.className} data-bs-toggle={props.bootsrapAction} href={props.href}>
          {props.icon}
        </a>
    )
}