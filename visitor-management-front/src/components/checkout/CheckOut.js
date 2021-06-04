import { Container, Form, Button } from "reactstrap";
import GenericHeader from "../common/GenericHeader";
import InputText from "../common/InputText";
import ModalCheckOut from "./ModalCheckOut";
import useSearchEmail from "../../hooks/useSearchEmail";

function CheckOut() {
   const {
      setEmailTyped,
      emailTyped,
      modal,
      setModal,
      toggle,
      handleSubmit,
      emailSearchedProps,
   } = useSearchEmail();

   const onSubmit = (data) => {
      setEmailTyped(data.emailSearched);
      setModal(true);
   };

   return (
      <section id="checkout">
         <GenericHeader />
         <Container>
            <h2 className="text-center m-4">
               {"Visite terminée. Départ de l'entreprise."}
            </h2>
            <Form onSubmit={handleSubmit(onSubmit)}>
               <InputText {...emailSearchedProps} />
               <Button size="lg" type="submit" color="success" block>
                  {"Terminer la visite"}
               </Button>
            </Form>
         </Container>
         <ModalCheckOut toggle={toggle} modal={modal} emailTyped={emailTyped} />
      </section>
   );
}

export default CheckOut;
