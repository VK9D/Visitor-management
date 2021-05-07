import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { Button, Col, Row } from 'reactstrap';
import DateTime from '../common/DateTime';
import { ModalTemplate } from '../common/ModalTemplate';
import { Languages } from '../common/Languages';

const Home = (props) => {
    const restoreData = {
        buttonColor: "danger",
        buttonLabel: <FontAwesomeIcon icon={["fas", "minus-circle"]} />,
        className: "test",
        modalTitle: "Etes-vous sûr⸱e ? (Démo uniquement)",
        modalBody: "Voulez-vous vraiment restaurer les données de l'application ? Cela aura pour conséquense de supprimer tous les visiteurs, visites et de reinitialiser les employés par défaut.",
        modalYesLabel: "Restaurer",
        modalNoLabel: "Annuler",
    }

    return (
        <section id="home">
            <Row>
                <Col><DateTime /></Col>
                <Col className="text-right"><Languages /></Col>
            </Row>
            <Row className="greetings">
                <Col className="align-self-center text-center">
                    <h1 className="h1 pb-4">Bienvenue dans notre entreprise</h1>
                    <Button size="lg" color="success">
                        S'enregistrer <span><FontAwesomeIcon icon={["fas", "chevron-circle-right"]} /></span>
                    </Button>
                </Col>
            </Row>
            <div className="footer">
                <div>
                    <Button color="primary" className="mr-2">
                        <span><FontAwesomeIcon icon={["fas", "door-open"]} /></span>
                        <span>Sortie</span>
                    </Button>
                    <Button color="primary">
                        <span><FontAwesomeIcon icon={["fas", "retweet"]} /></span>
                        <span>Déjà venu⸱e</span>
                    </Button>
                </div>
                <div className="text-danger">
                    <ModalTemplate {...restoreData} />
                </div>
            </div>
        </section>
    )
}

export { Home };