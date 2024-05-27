import './style.css'

export default function a(props) {
    return (
        <a className={props.className} data-bs-toggle={props.data-bs-toggle} href={props.href}>
          {props.icon}
        </a>
    )
}